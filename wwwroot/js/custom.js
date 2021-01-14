"use strict";
// "2017-06-01T08:30"

let d = new Date();
// yyyy-mm-ddThh:mm
let min = d.getFullYear() + 
    "-" + d.getMonth()    + 
    "-" + d.getDate()     + 
    "T" + d.getHours()    + 
    ":" + d.getMinutes();

document.getElementById("departure-datetime").min = min;

{

    let a = {
        key : {
            key : {
                key : {
                    key : null,
                    value : 3,
                },
                value : 2,
            },
            value : 1,
        },
        
        value : 0,
    };

    let node = a;
     
    while (node != null)
    {
        console.log(node.value);
        node = node.key;
        
    }

    console.log(123)

}
