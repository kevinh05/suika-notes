import sys
import librosa

if len(sys.argv) == 1:
	file_name = sys.argv[1]
	y, sr = librosa.load(file_name)
	y_harmonic, y_percussive = librosa.effects.hpss(y)

	
	



audio_file = ""