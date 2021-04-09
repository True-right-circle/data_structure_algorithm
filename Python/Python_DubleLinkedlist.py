# Hi my name is Jin Woo Won
# This Section is about Linked List
# Feature : Node(data, privious pointer ,next pointer) => Two-way access possible


# 1 Double Node
class Node:
    def __init__(self,data,prev=None,next=None):
        self.data = data
        self.prev = None
        self.next = None
    
# 2 Doublie Linked list Mng
class DoubleLinked:
    def __init__(self, data, head = None, tail = None):
        self.head = Node(data)
        self.tail = self.head
    
    # 3 insert
    def Add(self,data):
        node = self.head
        # 3 - 1 find last Node
        while node.next:
            node = node.next

        # create Node(data)
        new = Node(data)
        # connect node and created Node
        # connect new and node
        node.next = new
        new.prev = node
        self.tail = new

    # 4 insert data next
    def insert_of_data_next(self,data,select):
        node = self.head
        while node.next:
            if node.data == select:
                break
            else:
                node = node.next
        
        # node is select data node
        # new is insert data
        # 1. save node.next data
        temp = node.next
        # 2. create new Node
        new = Node(data)
        # 3. connect node.next and new
        node.next = new
        # 4. connect new.next and temp 
        new.next = temp
        #5. connect temp.prec and new
        temp.prev = new

    # 5 insert data prev with tail data
    def insert_of_data_prev(self,data,select):
        node = self.tail

        while node.prev:
            if node.data == select:
                break
            else:
                node = node.prev
            print(node.data)
        
        print(node.data)
        # 1 save node.prev
        temp = node.prev
        # 2 create new node
        new = Node(data)
        # 3 connect node.prev and new
        node.prev = new
        # 4 connect new.next and node
        new.next = node
        # 5 connect new.prev and temp
        new.prev = temp
        # 6. connect new and temp.next
        temp.next = new
    
    # 6 Delete data
    def delete(self,data):
        node = self.head
        # 1 find data node
        while node:
            if(node.data == data):
                # 1 save node.prev
                temp = node.prev
                # 2 connect node.next and temp
                node.next.prev = temp
                # 3 connect temp.next and node.next
                temp.next = node.next
                # 4 del node
                del node
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



linkedlist = DoubleLinked(0)

for i in range(1,10):
    linkedlist.Add(i)

linkedlist.Allprint()
linkedlist.delete(8)
linkedlist.Allprint()
linkedlist.insert_of_data_prev(3,7)
linkedlist.Allprint()
linkedlist.insert_of_data_next(8,7)
linkedlist.Allprint()
