# Hi my name is Jin Woo Won
# This Section is about Stack
# Feature : First in Last out
# push() -> stack data
# pop() -> take out last data
# Difficult to Manage data spcae(memory)

class Stack:
    myStack = list()

    def push(self, data):
        self.myStack.append(data)

    def pop(self):
        del self.myStack[-1]
    

mStack = Stack()

for i in range(50):
    mStack.push(i)

print(mStack.myStack)

print()
print()

for i in range(10):
    mStack.pop()

print(mStack.myStack)