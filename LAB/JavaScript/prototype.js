

function Human(age,name)
{
   this.age = age;
   this.name = name
}

Human.prototype.print = () => console.log(`name ${name} age ${age}`);


var human = new Human(22,"aymane");

console.log(Object.getPrototypeOf(human)); //print + constructor + object prototype
// {
//    print: () => console.log(`name ${name} age ${age}`)
//    constructor: ƒ Human(age,name)
//    [[Prototype]]: Object
// }

 console.log(human);
// {
//     age: 22
//     name: "aymane"
//     print: () => console.log(`name ${name} age ${age}`)
//     constructor: ƒ Human(age,name)
//     [[Prototype]]: Object
//  }



const person = {
    age:22,
    name:30
}

console.log(person);
//{
// age: 22
// name: 30
// [[Prototype]]: Object
//}

let person2 = Object.create(person);
//ajoute le prototype person a l'objet person2
console.log(person2); //[[Prototype]]: person.prototype


//let petson3 = {}
let person3 = Object.create(person);
//la methode .create vat lier person3 au prototype person
person3.ville ="casa";
//ajoute le prototype person a l'objet person2
console.log(person3); // { ville:'casa' ,[[Prototype]]: person.prototype }


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


function Car(version,color)
{
    this.version=version;
    this.color = color;
}

function BMW(cylindre)
{
    Car.call(this,2,"red")
    this.cylindre = cylindre
}

//cette syntaxe est erroner parce que je vais remplacer les propriter de l'objet bmw par le prototype Car
let bmw  = new BMW(11);
console.log(bmw); 
 // {
  //   cylindre: 11,
  //   [[Prototype]]: {
  //     constructor:function BMW(cylindre) ,
  //     [[Prototype]]: Object
  //   } 
// }  

bmw = Object.create(Car.prototype);
console.log(bmw);
 // {
  //   [[Prototype]]: {
  //     constructor: ƒunction Car(version,color),
  //     [[Prototype]]: Object
  //   } 
// } 

console.log(BMW.prototype);
//{
//   constructor:function BMW(cylindre),
//   [[Prototype]]: Object.prototype
//}


BMW.prototype = Object.create(Car.prototype);

//if i want to add function to prototype of BWN after initailisation with Object.create
// beacause all the existing property will be replaced

BMW.prototype.change =()=>{};

let bmw2 = new BMW(11);
console.log(bmw2);
// {version: 2, color: 'red', cylindre: 11,
// [[Prototype]]:[
//     [Prototype]]:{
//         constructor:ƒ Car(version,color),
//         [[Prototype]]:Object
//     }
// }


//dans le prototype on trouve le constructor et le pointeur __proto__
//BMW.prototype = Object.create(Car.prototype); cette syntaxe vat ecraser le prototype BMW est ajouter le prototype CAR
//[[Prototype]]:[
//     [Prototype]]:{
//         constructor:ƒ Car(version,color),
//         [[Prototype]]:Object
//     }

//donc le constructor de BMW serat introuvable

console.log(bmw2.cylindre);

//pour resoudre se probleme on ajoute la propriete constructor manuellement

 BMW.prototype.constructor = BMW; 
let bmw3 = new BMW(13);
console.log(bmw3);
// {version: 2, color: 'red', cylindre: 11,
// [[Prototype]]:[
//     [Prototype]]:{
//         constructor:ƒ BMW(cylindre),
//         [[Prototype]]:Object
//     }
// }


