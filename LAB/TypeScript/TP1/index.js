var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var id = 5;
var Name = "aymane";
var isTrue = true;
var Company = "mediaTech";
var tab = [1, 3, 4, 6];
var tab2 = ["hello", 1, 2, "not here", true];
//Tuple
var Pesonne = [22, "aymane", false];
//Tuple Array
var Employees;
Employees = [
    [22, 'aymane'],
    [18, 'yohane'],
];
//Union
var phone;
phone = 661111577;
phone = '661112577';
//Enumeration
var age;
(function (age) {
    age[age["child"] = 18] = "child";
    age[age["adult"] = 19] = "adult";
})(age || (age = {}));
var color;
(function (color) {
    color["red"] = "red";
    color["green"] = "green";
})(color || (color = {}));
console.log(color.red);
//Object
var user1 = {
    age: 22,
    name: 'aymane'
};
var user = { id: 1, name: 'aymane' };
//Type Assertion
var cid = 1;
var customerId = cid;
//customerId='aymane' error
var customerId2 = cid;
//function
function addNum(x, y) {
    return x + y;
}
function log(message) {
    console.log(message);
}
var user2 = {
    id: 1,
    name: 'aymane'
};
//interface Point=number|string    --->  error 
var point1 = 1;
var add = function (x, y) { return x + y; };
var sub = function (x, y) { return x - y; };
var Person = /** @class */ (function () {
    function Person(id, name) {
        this.id = id;
        this.name = name;
    }
    Person.prototype.register = function () {
        return "id ".concat(this.id, " name ").concat(this.name);
    };
    return Person;
}());
var person = new Person(1, 'aymane');
person.register();
//subclasses
var Employee = /** @class */ (function (_super) {
    __extends(Employee, _super);
    function Employee(id, name, salary) {
        var _this = _super.call(this, id, name) || this;
        _this.salary = salary;
        return _this;
    }
    return Employee;
}(Person));
var employee = new Employee(1, 'yohane', 50000);
//Generic
//Genric Function
function getArray(items) {
    return new Array().concat(items);
}
var numArray = getArray([1, 2, 3, 4, 'hhh']);
var strArray = getArray(['aymane', 'yohane']);
