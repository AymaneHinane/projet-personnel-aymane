import React from 'react'



const Childui=React.forwardRef((props,ref)=>{


    const hello=()=>{

    }

    return (
        <div>
            <p ref={ref}>UI child</p>
        </div>
    )
})

export default Childui
