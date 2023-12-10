let id:number=5;
let Name:string="aymane";
let isTrue:boolean=true;
let Company:any="mediaTech"
let tab:number[] = [1,3,4,6];
let tab2:any[] =["hello",1,2,"not here",true];

//Tuple
let Pesonne: [number,string,boolean] = [22,"aymane",false];

//Tuple Array
let Employees:[number,string][]
Employees=[
    [22,'aymane'],
    [18,'yohane'],
]

//Union
let phone:number|string
phone=661111577;
phone='661112577';

//Enumeration
enum age{
    child=18,
    adult
}

enum color{
    red = 'red',
    green = 'green'
}
console.log(color.red);

//Object
const user1:{
    age:number,
    name:string
}={
    age:22,
    name:'aymane'
}

//Object type

type User={
    id:Number,
    name:string
}

const user:User={id:1,name:'aymane'}


//Type Assertion
let cid:any=1
let customerId = <number>cid;
//customerId='aymane' error
let customerId2=cid as number


//function
function addNum(x:number,y:number) : number{
    return x+y;
}

function log(message:string | number) : void{
    console.log(message);
}


//Interface

interface UserInterface{
    readonly id:number,
    name:string,
    age?:number //optinnal
}

const user2:UserInterface={
    id:1,
    name:'aymane'
}

// user2.id=2;  we can't asign because the propertie is read only

type Point=number|string
//interface Point=number|string    --->  error 
let point1:Point=1


//Function Interface

interface MathFunc{
    (x:number,y:number): number
}

const add:MathFunc = (x:number,y:number): number => x+y
const sub:MathFunc = (x:number,y:number): number => x-y



//Classes

interface PersonneInterface{
     id:number,
    name:string,
    register():string
}

class Person implements PersonneInterface{
    //private id:number
    //protected name:string
    //accessible uniquement dans cette class ou les classes qui herite 
    id:number
    name:string

    constructor(id:number,name:string){
         this.id=id
         this.name=name
    }

    register()
    {
        return `id ${this.id} name ${this.name}`
    }
}

const person=new Person(1,'aymane')
person.register()

//subclasses
class Employee extends Person{
    salary:number

    constructor(id:number,name:string,salary:number)
    {
        super(id,name)
        this.salary=salary
    }
}

let employee=new Employee(1,'yohane',50000)

//Generic
//https://www.typescriptlang.org/docs/handbook/2/generics.html

//Genric Function

function getArray<T>(items:T[]):T[]{
    return new Array().concat(items);
}

let numArray=getArray<number>([1,2,3,4,5])
let strArray=getArray(['aymane','yohane'])


//Generic Interface

interface GenericIdentityFn {
    <Type>(arg: Type): Type;
  }
   
  function identity<Type>(arg: Type): Type {
    return arg;
  }
   
  let myIdentity: GenericIdentityFn = identity;


//Generic Classes
class GenericNumber<NumType> {
  zeroValue: NumType;

  constructor(zeroValue:NumType)
  {
      this.zeroValue=zeroValue
  }

  add(x: NumType, y: NumType): NumType
  {
      return x
  };
}
 
let myGenericNumber = new GenericNumber<number>();



