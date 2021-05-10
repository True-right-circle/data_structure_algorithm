# 음계

# 백준 음계 문제 2920
# 내장함수 all -> 인자로 주어진 리스트의 모든 요소가 true일 때 true를 반환하는 함수
# all(data[i]<data[i+1] for i in range(len(ages)-1))
# all안의 조건 -> 해당 문제 맞지 않음>
def solution(data):
    dummy = data.copy()
    dummy.sort()
    if data == dummy:
        print("ascending")
    elif data[::-1] == dummy:
        print("descending")
    else:
        print("mixed")


# 풀이
# 두개씩 묶으면서 오름/내림차순 여부를 체크 (1,2)->(2,3)->(3,4)
# 리스트를 순회 하면서 값을 비교하다 한 번이라도 안맞으면 True False
# pypy3를 사용하면 메모리는 더쓰지만 시간은 단축된다
#a = list(map(int, input().split(' '))) # 공백을 기준으로 인풋
def sol(data):
    ascending = True
    descending = True

    for i in range(1,8):
        if data[i] > data[i-1]:
            descending = False
        elif data[i]<data[i-1]:
            ascending = False
    
    if ascending:
         print("ascending")
    elif descending:
        print("descending")
    else:
        print("mixed")

#sol(a)



a = [1,2,3,4,5,6,7,8]
b = [8,7,6,5,4,3,2,1]
c = [8,1,7,2,6,3,5,4]

#solution(a)
#solution(b)
#solution(c)

# 백준 블랙잭 2798
# 풀이 3개씩 뽑아가 value에 가장 가까운수
# 제한이 100개의 카드이므로 삼중 for문을 사용해도 시간적인 문제는 없다

def black_sol(value,data):
    result = list()
    dummy = 0
    for i in range(len(data)):
        for j in range(i+1,len(data)):
            for k in range(j+1,len(data)):
                sum = data[i] + data[j] + data[k]
                if sum <= value:
                    dummy = max(sum,dummy) # -> 두개를 비교 후 더 큰수를 선택하는 max함수
                    result.append(sum)
    
    result.sort()
    print(result[-1])
    print(dummy)


def black_sol2(value,data):
    result = 0
    while data:
        dummy = data.pop(0)
        for i in range(len(data)):
            for j in range(i+1,len(data)):
                sum  = dummy + data[i] + data[j]
                if sum <= value:
                    result = max(sum,result)
                    
    
    print(result)


value = 21
data = [5,6,7,8,9]
black_sol2(value,data)


value = 500
data = [93,181,245,214,315,36,185,138,216,295]
black_sol2(value,data)
