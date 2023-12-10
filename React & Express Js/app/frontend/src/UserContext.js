
import axios from 'axios'
import React,{ createContext }  from 'react'
import { useEffect } from 'react'
import { useState } from 'react'


export const UserContext = createContext(null)

export default function UserContextProvider({children}) {

   const [user,setUser] = useState(null)
   const [connect,setConnect] = useState(false)
   
   useEffect(()=>{

      axios.get('/auth/profile').then(({data})=>{
         setUser(data);

      })

  },[connect])


  return (
    <UserContext.Provider value={{user,setUser,setConnect}}>
       {children}   
    </UserContext.Provider>
  )
}
