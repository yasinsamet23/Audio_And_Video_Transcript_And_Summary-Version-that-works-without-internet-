# Audio & Video Transcript and Summary (Offline)

Bu proje, video ve ses dosyalarını internetsiz olarak yazıya dönüştürür ve isterseniz özetini çıkarır.

---

## Model klasörleri

Bu proje, `aya-expanse-8b` ve `whisper_local` modellerini gerektirir.  
Aşağıdaki komutları kullanarak modelleri `Audio_And_Video_Summary` klasörüne indirebilirsiniz.

---

### 1. Python ile Hugging Face Hub’dan indirme

Önce Hugging Face hub paketini yükleyin:

```bash
pip install huggingface_hub



Ardından Python ile modelleri indirin:



from huggingface_hub import hf_hub_download
import os

# Hedef klasörleri oluştur
os.makedirs("Audio_And_Video_Summary/aya-expanse-8b", exist_ok=True)
os.makedirs("Audio_And_Video_Summary/whisper_local", exist_ok=True)

# aya-expanse-8b model dosyasını indir
hf_hub_download(
    repo_id="OWNER/aya-expanse-8b",  # OWNER kısmını Hugging Face kullanıcı/ad ile değiştirin
    filename="pytorch_model.bin",
    cache_dir="Audio_And_Video_Summary/aya-expanse-8b"
)

# whisper_local model dosyasını indir
hf_hub_download(
    repo_id="OWNER/whisper_local",  # OWNER kısmını Hugging Face kullanıcı/ad ile değiştirin
    filename="pytorch_model.bin",
    cache_dir="Audio_And_Video_Summary/whisper_local"
)






Not:

OWNER kısmını Hugging Face’deki kullanıcı veya organizasyon adıyla değiştirin.

filename kısmı modelin ana dosya adıdır, repo içindeki doğru dosyayı kullanın.




# Git LFS kurulumu
git lfs install

# Hugging Face reposunu klonla
git clone https://huggingface.co/OWNER/aya-expanse-8b Audio_And_Video_Summary/aya-expanse-8b
git clone https://huggingface.co/OWNER/whisper_local Audio_And_Video_Summary/whisper_local
