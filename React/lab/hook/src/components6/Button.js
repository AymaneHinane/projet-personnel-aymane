import React from 'react'


const Button=({value,btnColor,increment,btnIncrement,children})=>{
   
    console.log(children)

    return (
        <button style={{backgroundColor:btnColor}} onClick={()=>btnIncrement(value)}>+{increment}%</button>
    )
}

export default React.memo(Button)
