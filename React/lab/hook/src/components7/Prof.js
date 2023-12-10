import React,{useState,useEffect} from 'react'


const Prof=({count,profile})=>{

    console.log('profile0')
    return (
        <div>
            <h2>ID: {count}</h2>
            <ul>
                <li>name: {profile.name}</li>
                <li>email: {profile.email}</li>
            </ul>
        </div>
    )
}

export default React.memo(Prof)
