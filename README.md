# 🎥 Audio and Video Transcript And Summary Application

This project transcribes an audio or video file and then extracts its summary in Turkish using the OpenAI API. Python scripts (`transcribe.py`, `transcribe_split.py`, `summarize.py`) are integrated with a C# Windows Forms interface.

---

## 🔐 API Key Entry

You must enter your API Key in the OpenAI API input fields in the following Python files:

- `transcribe.py`
- `transcribe_split.py`
- `summarize.py`

## ⚙️ Installation Steps

Before using the project, you must complete the following installation steps.

### 🐍 Python Requirement

- Python 3.8 or later must be installed on your computer.

- Download Python: [https://www.python.org/downloads/](https://www.python.org/downloads/)

### 📦 Required Python Libraries

You can install the necessary libraries by typing the following commands in the terminal or command prompt (CMD):

```bash
pip install moviepy==1.0.3
pip install openai
pip install ffmpeg-python
