//////////////////  Type //////////////////////


let isTrue:boolean; //c# java false     js undefined 
let a:number;

//--we canot access to yhis variable because it's not yet assigned
//console.log(isTrue);   
//console.log(a);

let emplist:string[];
emplist = ["yohane","noa","ellie"];

let results1 = emplist.filter( e => e == "yohane" ); //string[]
let results2 = emplist.find( e => e == "yohane" ); //string|undefined


const enum Color{
    red,
    blue
}

let c:Color=Color.red;


let Employe:[string,string];

function GetEmployee(Name:string,Departement:string):[string,string]
{
   return [Name,Departement];
}

Employe = GetEmployee("aymane","nora");
Employe[0];
Employe[1];



//////////////////  Function //////////////////////

function Add1(num1:number,num2:number,num3?:number):number
{
    return num3 ? num1 + num2 + num3 : num1 + num2 ;
}


function Add2(num1:number,num2:number,num3:number=0):number
{
    return  num1 + num2 + num3 ;
}


function Add3(num1:number,num2:number,...num3:number[]):number
{
    return  num1 + num2 +  num3.reduce((acc,som)=>acc+som) ;
}

let Add3Result_1 = Add3(2,4,4,5,6,7,9);
let Add3Result_2 = Add3(2,4,...[4,5,6,7,9])
let tab1 = [4,5,6,7,9]
let Add3Result_3 = Add3(2,4,...tab1);


function getItem<Type>(items:Type[]):Type[]
{
    return new Array<Type>().concat(items);
}

let tabNum:number[] = [1,3,5,8,9];
tabNum = getItem<number>(tabNum);



//////////////////  Classes //////////////////////

import { IJob ,IUser} from "./Interface";

interface Iadresse{
    city:string,
    zipcode:number,
    adresse?:string
}

interface IHuman{
   fname:string
}

interface IEmployee extends IHuman{
   id:number;
   print():string;
}

class Employee implements IEmployee{

    private static Id:number = 0;
    public id:number;
    public fname:string;
    protected adresse:Iadresse;

    set Setfname(value:string){
        if(value != "")
          this.fname = value;
        throw Error("fname can't be empty")
        
    }

    constructor(fname:string,adresse:Iadresse)
    {
      this.fname=fname;
      this.id = ++Employee.Id;
      this.adresse = adresse;
    }

    print():string{
        return `id ${this.id} name ${this.fname} `
    }
}

class Manager extends Employee{
    
    constructor(fname:string,adresse:Iadresse)
    {
        super(fname,adresse);
    }
}


let manager:Manager = new Manager("aymane",{city:"casa",zipcode:26000});


let user:IUser = {name:"aymane",age:22};
let { name : username , age:userage } = user;

let {name,age}:IUser = {name:"aymane",age:22};



let [user1,user2]:IUser[] = [
    {name:"aymane",age:22},
    {name:"aymane",age:22}
]