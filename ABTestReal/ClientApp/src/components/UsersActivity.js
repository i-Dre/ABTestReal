import React, { Component } from 'react';
import moment from 'moment';
import { Table, Button, ButtonGroup } from 'react-bootstrap';
import { AddUserActivity } from './AddUserActivity';
import { BarGraph } from './BarGraph';
import Grid from "@material-ui/core/Grid";



export class UsersActivity extends Component {
    constructor(props) {
        super(props);
        this.state = {
            deps: [],
            addModalShow: false,
            showHideBarGraph: false
        };
    }

    refreshList() {
        fetch('UserActivity')
            .then(response => response.json())
            .then(data => {
                this.setState({ deps: data });
            });
    }

    toggleComponent = () => {
        this.setState({
            showHideBarGraph: !this.state.showHideBarGraph
        });

    }

    componentDidMount() {
        this.refreshList();
    }


    render() {
        const { deps } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false }, this.refreshList());

        return (
            <Grid container spacing={3}>
                <Grid item xs={6}>
                    <Table className="tableMS">
                        <thead>
                            <tr className="tableMS-header">
                                <th>ID</th>
                                <th>Дата регистрации</th>
                                <th>Дата последнего входа</th>
                            </tr>
                        </thead>
                        <tbody>
                            {deps.map(dep =>
                                <tr key={dep.id}>
                                    <td>{dep.id}</td>
                                    <td>{moment(dep.registrationDate).format("DD.MM.YYYY")}</td>
                                    <td>{moment(dep.lastActivityDate).format("DD.MM.YYYY")}</td>
                                </tr>
                            )}
                        </tbody>
                    </Table>
                </Grid>
                <Grid item xs={6}>
                    {this.state.showHideBarGraph ? <BarGraph /> : null}
                </Grid>

                <ButtonGroup disableElevation variant="contained" aria-label="contained primary button group">
                    <Button className="buttonMS"
                        onClick={() => this.setState({ addModalShow: true })}>
                        Добавить пользователя</Button>
                    <Button className="buttonMS" onClick={this.toggleComponent}>Нарисовать гистограмму</Button>
                </ButtonGroup>
                <AddUserActivity show={this.state.addModalShow} c
                    onHide={addModalClose} />
            </Grid>
        )
    }
}