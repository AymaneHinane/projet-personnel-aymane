import React from 'react'
import {MyContext} from './MyContext'


class User extends React.Component{



  render(){

    let value = this.context;
    console.log(value)
      return (
        
                     <div>
                         <p>hello</p>
                           <h2></h2>
                     </div>
                      
    ) 
  }

          
}


User.contextType = MyContext;
export default User
