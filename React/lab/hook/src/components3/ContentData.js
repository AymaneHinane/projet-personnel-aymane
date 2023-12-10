import React,{useContext} from 'react'
import {userContext,ColorContext} from './MyContent'

const ContentData=()=>{
     
    const user = useContext(userContext);
    const color = useContext(ColorContext);

    return (
        <div>
            <h1 style={{color:color}}> {user.name}</h1>
        </div>
    )
}

export default ContentData
