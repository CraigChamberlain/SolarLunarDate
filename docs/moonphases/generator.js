var target = document.getElementById('target')
for (let index = 1; index < 4584; index++) {
    var div = document.createElement("div");
    div.id = index;
    if(Math.random() < .4){
        div.style ="visibility:hidden;"
    }
    target.appendChild(div)
    
}
