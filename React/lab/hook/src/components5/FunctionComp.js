import React from 'react'

const FunctionComp=(props)=>{


   console.log('function Componant')

    return (
        <div>
            <h2>function Componant</h2>
            <p>{props.name}</p>
        </div>
    )
}

export default React.memo(FunctionComp)
