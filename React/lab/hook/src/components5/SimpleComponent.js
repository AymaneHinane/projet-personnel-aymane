import React from 'react'


class SimpleComponent extends React.Component{

    render(){
        console.log('render enfant')
       return (
        <div>
            <h2>SimpleComponent</h2>
        </div>
    ) 
    }
    
}

export default SimpleComponent
