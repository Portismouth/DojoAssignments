function studentsInstructors(users){
    for(var key in users){
        if(users.hasOwnProperty(key)){
            console.log(key);
            var studentList = users[key];
            var count = 1;
            for(var i in studentList){
                var first = studentList[i].first_name;
                var last = studentList[i].last_name;
                var length = first.length + last.length;
                console.log(count.toString(), '-', first, last, '-', length);
                count++;
            }
        }
    }
    
}

var users = {
    'Students': [ 
        {first_name:  'Michael', last_name : 'Jordan'},
        {first_name : 'John', last_name : 'Rosales'},
        {first_name : 'Mark', last_name : 'Guillen'},
        {first_name : 'KB', last_name : 'Tonel'}
     ],
    'Instructors': [
        {first_name : 'Michael', last_name : 'Choi'},
        {first_name : 'Martin', last_name : 'Puryear'}
     ]
    }

studentsInstructors(users);