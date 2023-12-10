import React,{useState,useEffect} from 'react'

const FunctionCount=()=>{    

    const [keyCode,setKeyCode]=useState('')

    const handleKeyCode = e => {
        setKeyCode(e.code)
    }

    useEffect(()=>{
        document.addEventListener("keyup",handleKeyCode)

        return () =>{
            document.removeEventListener("keyup",handleKeyCode)
        }
    },[])
   
    return (
        <div>
            <h1>Fuction</h1>
            <h2>{keyCode}</h2> 
        </div>
    )
}

export default FunctionCount
