# Hi my name is Jin Woo Won
# This Section is about Linked List
# Feature : Node(data, pointer)
# # Not need Size of data
# need spqce for pointer
# need time for searching connection info
# complex for delete Node

# step1 Node Class
class Node:
    def __init__(self,data,next=None): # when create Node next(pointer info) is null
        self.data = data
        self.next = next

# step2 Nonde Manage Class
class NodeMng:
    head = None

    # 1 - Create and set head
    def __init__(self, data): # set head Node
        if self.head == None:
            self.head = Node(data)
    
    # 2 - Add func
    def Add(self,data):
        node = self.head
        # 2-1. Searchin Last Node -  when node.next is null
        while node.next:
            node = node.next
        # 2-2. when the find node(node.next == null) create node and connenct
        new = Node(data)
        node.next = new

    # 3 - Delete func
    def delete(self,data):
        # 3 delete head
        if self.head.data == data:
            temp = self.head
            self.head = self.head.next
            del temp
        else:
            node = self.head

            # 3 - 1 find node that node.next.data equlas delete data
            while node:
                if node.next.data == data:
                    break
                else:
                    node = node.next
        
            # 3 - 2 connect and delete process
            # node is privious data of delete data
            # node.next.next is after data of delete data
            temp = node.next
            node.next = node.next.next
            del temp
    
    # 4 - search func
    def search(self, data):
        node = self.head
        while node:
            if node.data == data:
                print("Find data ", node.data)
                return
            else:
                node = node.next
        print("No ",data)
    
    def Allprint(self):
        node = self.head
        dummy = ""
        while node:
            dummy +=str(node.data)+" "
            node = node.next
        print(dummy)


linkedlist = NodeMng(0)

for i in range(1,10):
    linkedlist.Add(i)

linkedlist.Allprint()
linkedlist.search(10)
linkedlist.search(8)
linkedlist.delete(8)
linkedlist.search(8)
linkedlist.Allprint()
linkedlist.delete(0)
linkedlist.Allprint()