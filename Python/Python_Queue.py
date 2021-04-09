# Hi my name is Jin Woo Won
# This Section is about Queue
# Feature : First in Firts Out, Last in Last out

# Example with List()

class Queue:
    mQueue = list()

    def Enqueue(self,data):
        self.mQueue.append(data)

    def Dequeue(self):
        del self.mQueue[0]


my = Queue()

for i in range(50):
    my.Enqueue(i)

print(my.mQueue)

for i in range(20):
    my.Dequeue()

print()
print()

print(my.mQueue)