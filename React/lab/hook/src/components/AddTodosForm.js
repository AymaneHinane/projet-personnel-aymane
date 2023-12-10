import React,{useState} from 'react'

const AddTodosForm=({addNewTodo})=>{

    const [addTodo,setAddTodo]=useState('')
     console.log(addTodo)

     const handleTodo=(e)=>{
        addNewTodo(addTodo); 
        e.preventDefault();
        setAddTodo('');
     }

    return(
        <form onSubmit={handleTodo}>
            <label>ajouter Todo</label>
            <input type="text" value={addTodo} onChange={(e)=>setAddTodo(e.target.value)}/>
            <input type="submit" />
        </form>
    )
}

export default AddTodosForm
