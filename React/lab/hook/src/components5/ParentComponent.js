import React, { Component, PureComponent } from 'react'
import SimpleComponent from './SimpleComponent'
import PureComp from './PureComponent'
import FunctionComp from './FunctionComp'

class ParentComponent extends Component {


     constructor(props)
     {
         super(props)

         this.state={
             name:'SpiderMan'
         }
     }

     changeToBatman=()=>{
         this.setState({
             name:'Batman'
         })
     }

 /*    shouldComponentUpdate(nextPorps,nextState)
     {
         console.log('parent shouldComponentUpdate()')
          
         if(this.state.name !== nextState.name)
          {
              return true;
          }
          return false;

         //return true   mise a jour du render
         //return false  pas de mise a jour block le render 
     }
   */   
    
    render() {
        console.log('render parent')
        return (
            <div>
                <h2>ParentComponent</h2>
                <SimpleComponent name={this.state.name} />
                <PureComp name={this.state.name} />
                <FunctionComp name={this.state.name} />
                <button onClick={this.changeToBatman}>changer en batman</button>
            </div>
        )
    }
}

export default ParentComponent
