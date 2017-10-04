my_dict = {
  "Speros": "(555) 555-5555",
  "Michael": "(999) 999-9999",
  "Jay": "(777) 777-7777"
}
def dict_tuple(dictionary):
    tuple_list = []
    for key, value in dictionary.iteritems():
        tuple_list.append((key,value))
    print tuple_list

dict_tuple(my_dict)