import React, { Component } from 'react'

export class Form extends Component {

   state = {
       username:'',
       color:'',
       colors:['','vert','rouge','orange'],
       comment:''
   }

   handlePseudo = (e) =>{
       console.log(e.target.value)
       this.setState({
           username:e.target.value
       })
   }

   handleColor=(e)=>{
       this.setState({
           color:e.target.value
       })
       console.log(this.state.color)
   }

   handleComments=(e)=>{
    this.setState({
        comment:e.target.value
    })
   }


    render() {
        return (
            <div>
                <form>
                    <label>Pseudo</label>
                    <input type="text" value={this.state.username} onChange={this.handlePseudo} />

                    <label>Couleur</label>
                    <select value={this.state.color} onChange={this.handleColor}>
                        {
                            this.state.colors.map((color,key)=>{
                                return <option key={key} value={color}>{color}</option>
                            })                     
                        }
                        
                    </select> 

                    <label>Commentaire</label>
                    <textarea value={this.state.comment} onChange={this.handleComments} >

                    </textarea>
                </form>
            </div>
        )
    }
}

export default Form


