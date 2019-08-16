#area.py文件需要用到const.py文件中的PI变量
from const import PI  
 
def calc_round_area(radius):
    return PI * (radius ** 2)
def main():
    print("round area: ", calc_round_area(2))
main()