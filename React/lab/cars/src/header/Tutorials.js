import React from 'react'

const Tutorials=(props)=>{
     
    //uniquement les composants qui ont un route
    console.log(props)

    setTimeout(()=>{
          props.history.push('/')
    },5000)

    return (
        <div>
              <p>alert</p>
             <h1>Tutorials</h1>
        </div>
    )
}

export default Tutorials
