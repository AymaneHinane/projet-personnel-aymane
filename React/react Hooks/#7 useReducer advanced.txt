import React,{useReducer} from 'react'


const initialState={
    countOne:0,
    countTwo:0
};

const reducer=(state,action)=>{
     const {type,value}=action

     switch(type)
     {
         case 'increment1':
             return {...state,countOne:state.countOne+value}
         case 'increment2':
             return {...state,countTwo:state.countTwo+value}
          case 'reinitialise':
             return initialState;
     }
}


const Count=()=>{

    const [count, dispatch] = useReducer(reducer, initialState)

    return (
       <>
           <div>
             <h1>{count.countOne}</h1>
             <button onClick={() => dispatch({type:'increment1', value:1})}>+</button>            
           </div>
           <div>
             <button onClick={() => dispatch({type:'reinitialise', value:0})}>reinitialser</button>
           </div>
           <div>
             <h1>{count.countTwo}</h1>
             <button onClick={() => dispatch({type:'increment2', value:1})}>+</button>
           </div>
       
       </>  
        
        
    )
}

export default Count
