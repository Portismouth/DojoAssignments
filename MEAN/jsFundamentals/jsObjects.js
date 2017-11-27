let students = [
    {name: 'Remy', cohort: 'Jan'},
    {name: 'Genevieve', cohort: 'March'},
    {name: 'Chuck', cohort: 'Jan'},
    {name: 'Osmund', cohort: 'June'},
    {name: 'Nikki', cohort: 'June'},
    {name: 'Boris', cohort: 'June'}
];

function printObject(objects){
    for(let student in objects){
        let info = objects[student]
        let msg = ""
        for(let key in info){
            // console.log(key+":", info[key])
            msg += key+": "+info[key]+", "
        }
        console.log(msg)
    }
}
// printObject(students);


let users = {
    employees: [
        {'first_name':  'Miguel', 'last_name' : 'Jones'},
        {'first_name' : 'Ernie', 'last_name' : 'Bertson'},
        {'first_name' : 'Nora', 'last_name' : 'Lu'},
        {'first_name' : 'Sally', 'last_name' : 'Barkyoumb'}
    ],
    managers: [
       {'first_name' : 'Lillian', 'last_name' : 'Chambers'},
       {'first_name' : 'Gordon', 'last_name' : 'Poe'}
    ]
 };

 function printStuff(objects){
     for(let role in objects){
         console.log(role.toUpperCase())
         let values = objects[role]
         for(let key in values){
            let user = values[key]
            let name = user['first_name']+user['last_name']
            let counter = parseInt(key) 
            console.log("",counter+1,"-",user['first_name']+", "+user['last_name'],"-",name.length)
         }
     }
 }

 printStuff(users)