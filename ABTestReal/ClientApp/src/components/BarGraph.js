import React, { Component } from 'react';
import { Line } from 'react-chartjs-2';

export class BarGraph extends Component {
    constructor(props) {
        super(props);
        this.state = { rrs: [] }
    }

    refreshList() {
        fetch('UserActivity/calc')
            .then(response => response.json())
            .then(data => {
                this.setState({ rrs: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {

    }

    render() {
        const { rrs } = this.state;
        const data = {
            labels: ["1 day", "2 day", "3 day", "4 day", "5 day", "6 day", "7 day"],
            datasets: [{
                label: "Rolling retention 7 days",
                fill: false,
                backgroundColor: 'rgba(73,155,234,1)',
                borderColor: 'rgba(73,155,234,1)',
                pointBorderColor: 'rgba(73,155,234,1)',
                pointBorderWidth: 1,
                pointHoverRadius: 5,
                pointHoverBackgroundColor: 'rgba(73,155,234,1)',
                pointHoverBorderColor: 'rgba(73,155,234,1)',
                pointRadius: 1,
                pointHitRadius: 10,
                data: rrs
            }]
        }
        return (
            <div>
                <Line data={data} />
            </div>
        )
    }
}
export default BarGraph;