import React, { Component } from 'react'
import ReactDOM from 'react-dom'
export class Modal extends Component {

    constructor(props)
    {
        super(props)

       this.popUpcontainer=document.createElement('div')
      // this.popUpcontainer.setAttribute('class','second-root')
       
    }


    componentDidMount()
    {
       document.body.appendChild(this.popUpcontainer);
    }
    componentWillUnmount()
    {
        document.body.removeChild(this.popUpcontainer);
       //document.body.getElementsByClassName('second-root').remove()
    }
    
    render() {
        
        return ReactDOM.createPortal (
            <div className="modal" onClick={this.props.close}>
                <div>
                    <p>hello wold</p>
                    <button >Fermer</button>
                </div>
            </div>
            ,this.popUpcontainer
        )
    }
}

export default Modal
