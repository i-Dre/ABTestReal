import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';


export class AddUserActivity extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch('UserActivity', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id: 0,
                RegistrationDate: event.target.RegistrationDate.value,
                LastActivityDate: event.target.LastActivityDate.value
            })
        })
            .then(res => res.json())
            .then((result) => {
                console.log('all cool');
                this.props.onHide();
            },
                (error) => {
                    console.log('all bad');
                })
    }

    render() {
        return (
            <div className="container">
                <Modal
                    {...this.props} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Добавление пользователя
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="register">
                                        <Form.Label>Дата регистрации</Form.Label>
                                        <Form.Control type="date" name="RegistrationDate" />
                                    </Form.Group>
                                    <Form.Group controlId="lastActiv">
                                        <Form.Label>Дата последнего входа</Form.Label>
                                        <Form.Control type="date" name="LastActivityDate" />
                                    </Form.Group>
                                    <Form.Group>
                                        <Button variant="primary" type="submit">Добавить</Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>
                    <Modal.Footer>
                   
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }
}