import React, {PureComponent } from 'react'

export class Purecomponent extends PureComponent {
    render() {
        console.log('Pure')
        return (
            <div>
                <p>pure</p>
            </div>
        )
    }
}

export default Purecomponent
