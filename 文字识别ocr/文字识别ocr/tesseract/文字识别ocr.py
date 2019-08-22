from PIL import Image
from pytesseract import pytesseract
image = Image.open('G:/img/126.png')
code = pytesseract.image_to_string(image, lang='chi_sim')
print(code)

