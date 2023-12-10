import React,{Component} from 'react'
import Toto from './Toto'

class Maman extends Component{

    state={
       messageMaman:null,
       messageToto:null
    }

    ordreMaman= () => {
        this.setState({
            messageMaman:'va renger ta chambre'
        })
    }

    reponseToto=() => {
        this.setState({
            messageToto:"D'accord maman"
        })
    }

   render(){
       
       return(
            <div>
                <h1>Maman</h1>
                <button onClick={this.ordreMaman}>Ordre de la mere </button>
                <p>{this.state.messageMaman}</p>
                <hr/>
                <Toto name="Toto" leState={this.state} reponse={this.reponseToto}></Toto>

            </div>
       )
   }

}

export default Maman;