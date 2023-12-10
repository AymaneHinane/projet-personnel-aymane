import React,{Component,Fragment} from 'react'
import Car from './Cars';



class Mycars extends Component {

    state={
        voitures:[
            {name:'Ford',color:'red',year:2000},
            {name:'dacia',color:'green',year:2020},
            {name:'renault',color:'orange',year:2015}
        ]
    }
    
    addTenYears= (id) => {
        const updatedState = this.state.voitures.map((param,key)=>{
            return id===key?param.year +=10:param.year;
        })

        this.setState({
            updatedState
        })
    }

    render(){
        return(
            <div>
                <h1>{this.props.title}</h1>

                {
                    
                    this.state.voitures.map((voiture,key)=>{
                        
                       return(
                           <Fragment key={key}>
                           <Car  color={voiture.color}>{voiture.name} {voiture.year} </Car>
                           <button onClick={this.addTenYears.bind(this,key)}>add +10</button>
                          </Fragment>
                       ) 
                    })
                }

            </div>
            
        )
    }
} 

export default Mycars;