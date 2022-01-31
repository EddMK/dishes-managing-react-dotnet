import React, { Component } from 'react';
import { GrEdit } from "react-icons/gr";
import Button from '@mui/material/Button';

export default class ButtonEdit extends Component {
    handleClick = () => {
        console.log("COMP BOUTON : "+this.props.value);
        this.props.onButtonClick(this.props.value);
    }

    render() {
        return (
          <Button variant="contained"  onClick={this.handleClick} ><GrEdit/></Button>
        );
    }
}