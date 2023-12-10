import React,{useState} from 'react'
import AddTodosForm from './AddTodosForm'
 import { v4 as uuidv4 }  from 'uuid';


const FunctionState=()=>{
 
    
    const [todos,setTodos]=useState([
        {id:1 , todo: 'Acheter du lait'},
        {id:2 , todo: 'Acheter du lait'},
    ])

    const [warning,setWarning] = useState(false);
    
    //console.log(todos[todos.length-1])

    const myTodos = todos.map(todo=>{
         return(
             <li key={todo.id}>{todo.todo}</li>
         )
     })

     const addNewTodo=(newTodo)=>{
         if(newTodo !== '')
         {
             setTodos([...todos,{id:uuidv4(),todo:newTodo}]) 
             setWarning(false) 
         }else{
            setWarning(true) 
         }
           
     }

  
    return (
        <div>
            <h1> {todos.length} Todos </h1>
            
            <ul>
                {myTodos}            
            </ul>
            
            <AddTodosForm addNewTodo={addNewTodo}/>
            <h2>{warning&&"veuillez entrer une chaine"}</h2>
        </div>
    )
}

export default FunctionState
