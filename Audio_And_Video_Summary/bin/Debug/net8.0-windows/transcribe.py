import sys
import os
import torchaudio
import torch
import subprocess
from transformers import AutoModelForSpeechSeq2Seq, AutoProcessor, pipeline
from pathlib import Path

# --- whisper_local klasörünü bulmak için transcribe.py dosyasının gerçek konumunu kullan ---
base_dir = Path(__file__).resolve()
while not base_dir.name == "Audio_And_Video_Summary":
    base_dir = base_dir.parent
local_model_dir = base_dir / "whisper_local"

if not local_model_dir.exists():
    raise FileNotFoundError(f"whisper_local klasörü bulunamadı: {local_model_dir}")

local_model_dir_str = str(local_model_dir)

# (Aşağıdaki kod aynı kalacak...)
device = "cuda" if torch.cuda.is_available() else "cpu"
torch_dtype = torch.float16 if torch.cuda.is_available() else torch.float32

model = AutoModelForSpeechSeq2Seq.from_pretrained(
    pretrained_model_name_or_path=local_model_dir_str,
    torch_dtype=torch_dtype,
    low_cpu_mem_usage=True,
    use_safetensors=True,
    local_files_only=True
).to(device)

processor = AutoProcessor.from_pretrained(
    pretrained_model_name_or_path=local_model_dir_str,
    local_files_only=True
)

pipe = pipeline(
    "automatic-speech-recognition",
    model=model,
    tokenizer=processor.tokenizer,
    feature_extractor=processor.feature_extractor,
    torch_dtype=torch_dtype,
    device=device,
)

def convert_to_wav(input_path, output_path):
    command = [
        "ffmpeg",
        "-i", input_path,
        "-ar", "16000",
        "-ac", "1",
        "-f", "wav",
        output_path,
        "-y"
    ]
    subprocess.run(command, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)

input_path = sys.argv[1]
ext = os.path.splitext(input_path)[1].lower()
temp_wav_path = "temp_input.wav"

if ext != ".wav":
    convert_to_wav(input_path, temp_wav_path)
    audio_path = temp_wav_path
else:
    audio_path = input_path

waveform, sample_rate = torchaudio.load(audio_path)
duration_sec = waveform.shape[1] / sample_rate

chunk_duration = 30
full_text = ""

for i in range(0, int(duration_sec), chunk_duration):
    start_sample = int(i * sample_rate)
    end_sample = int(min((i + chunk_duration) * sample_rate, waveform.shape[1]))
    chunk = waveform[:, start_sample:end_sample]

    temp_chunk = f"temp_chunk_{i}.wav"
    torchaudio.save(temp_chunk, chunk, sample_rate)

    result = pipe(temp_chunk, generate_kwargs={"language": "turkish"})
    full_text += result["text"] + " "

    os.remove(temp_chunk)

if os.path.exists(temp_wav_path):
    os.remove(temp_wav_path)

print(full_text)
