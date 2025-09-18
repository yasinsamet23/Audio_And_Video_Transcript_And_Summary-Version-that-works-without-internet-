import os
import sys
import torch
from transformers import AutoTokenizer, AutoModelForCausalLM, BitsAndBytesConfig
import re
from pathlib import Path

# Model yolu

model_path = Path(__file__).resolve()
while not model_path.name == "Audio_And_Video_Summary":
    model_path = model_path.parent
model_path = model_path / "aya-expanse-8b"

if not model_path.exists():
    raise FileNotFoundError(f"aya-expanse-8b klasörü bulunamadı: {model_path}")

model_path = str(model_path)







# Cihaz seçimi
device = "cuda" if torch.cuda.is_available() else "cpu"

# Tokenizer yükle
tokenizer = AutoTokenizer.from_pretrained(model_path, local_files_only=True)

# 4-bit quantization ayarı
quant_config = BitsAndBytesConfig(load_in_4bit=True)

# Model yükle
model = AutoModelForCausalLM.from_pretrained(
    model_path,
    local_files_only=True,
    quantization_config=quant_config,
    device_map="auto"
)

# Komut satırından gelen txt dosyasını oku
input_path = sys.argv[1]
with open(input_path, "r", encoding="utf-8") as f:
    text = f.read()

# Prompt hazırla (daha net bir yönerge)
prompt = f"Metni Türkçe olarak özetle. Önemli mesajları ve ana noktaları ver, uzunluğu sana bırakılmış:\n\n{text}"

# Tokenize et
inputs = tokenizer(prompt, return_tensors="pt", truncation=True, max_length=1024).to(device)

# Özet üret
summary_ids = model.generate(
    **inputs,
    max_new_tokens=1000,  # uzun özetler için yeterli
    do_sample=False,      
    temperature=0.7,
    top_p=0.9,
    repetition_penalty=1.2
)

# Çıktıyı decode et
raw_summary = tokenizer.decode(summary_ids[0], skip_special_tokens=True)
raw_summary = re.sub(r"<extra_id_\d+>", "", raw_summary).strip()

# Eğer model **Özet:** kelimesi eklediyse, ondan sonrasını al



summary = raw_summary

if prompt in summary:
    summary = summary.split(prompt, 1)[1].strip()

if "Özet:" in summary:
    summary = summary.split("Özet:", 1)[1].strip()

print(summary)
