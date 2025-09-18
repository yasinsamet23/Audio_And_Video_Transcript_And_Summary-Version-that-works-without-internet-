# Audio & Video Transcript and Summary (Offline)

Bu proje, video ve ses dosyalarını internetsiz olarak yazıya dönüştürür ve isterseniz özetini çıkarır.

---

⚙️ Kurulum Adımları

Projeyi kullanmadan önce aşağıdaki adımları tamamlamalısınız:

🐍 Python Gereksinimi

Python 3.8 veya üzeri sisteminizde kurulu olmalıdır.
Python’u buradan indirebilirsiniz: https://www.python.org/downloads/

📦 Gerekli Python Kütüphaneleri

Terminal veya Komut İstemi (CMD) üzerinden aşağıdaki komutları çalıştırarak gerekli kütüphaneleri yükleyin:

pip install ffmpeg-python
pip install torch torchaudio transformers


Not: torch, torchaudio ve transformers paketleri, ses/video transkripsiyonu ve özetleme işlemleri için gereklidir.

## Model klasörleri

Bu proje, `aya-expanse-8b` ve `whisper-large-v3` modellerini gerektirir.  
Aşağıdaki komutları kullanarak modelleri `Audio_And_Video_Summary` klasörüne indirebilirsiniz.

---

### 1. Python ile Hugging Face Hub’dan indirme

Önce Hugging Face hub paketini yükleyin:

```bash
pip install huggingface_hub



Ardından Python ile modelleri indirin:



from huggingface_hub import snapshot_download
import os

# Hedef klasörleri oluştur
os.makedirs("Audio_And_Video_Summary/aya-expanse-8b", exist_ok=True)
os.makedirs("Audio_And_Video_Summary/whisper_local", exist_ok=True)

# CohereLabs/aya-expanse-8b modelini indir
snapshot_download(
    repo_id="CohereLabs/aya-expanse-8b",
    local_dir="Audio_And_Video_Summary/aya-expanse-8b"
)

# OpenAI Whisper modeli (openai/whisper-large-v3) indir
snapshot_download(
    repo_id="openai/whisper-large-v3",
    local_dir="Audio_And_Video_Summary/whisper_local"
)



2. Git LFS ile direkt klonlama (alternatif):



# Git LFS kurulumu


git lfs install

# Hugging Face reposunu klonla
git clone https://huggingface.co/CohereLabs/aya-expanse-8b Audio_And_Video_Summary/aya-expanse-8b
git clone https://huggingface.co/openai/whisper-large-v3 Audio_And_Video_Summary/whisper_local


