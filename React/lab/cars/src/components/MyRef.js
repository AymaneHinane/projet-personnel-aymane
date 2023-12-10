import React, { Component } from 'react'



const MyRef= React.forwardRef((props,ref)=>{

       return (
            <div>
                <input ref={ref} type="text"  />
            </div>
        )

})
        


export default MyRef
