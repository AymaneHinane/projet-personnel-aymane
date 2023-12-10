import React, { Component } from 'react'

export class ClassCount extends Component {

    constructor(props)
    {
        super(props);

         this.state={
             keyCode: null
         }
    }

    handleKeyCode = e =>{
          console.log(e.code )
        this.setState({
         keyCode:e.code 
        })
    }
    

     componentDidMount()
     {
         document.addEventListener("keyup",this.handleKeyCode)
     }

     componentWillUnmount()
     {
         document.removeEventListener("keyup",this.handleKeyCode)
     }
   
    render() {
        const {keyCode}=this.state

        return (
            <div >
                <p>{keyCode}</p>
                <p>hello</p>
            </div>
        )
    }
}

export default ClassCount
