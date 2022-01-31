import React, { Component } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent  from '@mui/material/DialogContent';
import Alert from '@mui/material/Alert';
import AlertTitle from '@mui/material/AlertTitle';

export default class Confirmation extends Component {

    constructor(props){
        super(props);
        this.state = { open : true };
    }

    render(){
        return(                       
            <Dialog open={this.state.open} >
                <DialogContent>
                        <Alert variant="outlined" severity="info">
                            <AlertTitle>Confirmation</AlertTitle>
                                Etes-vous sûr de vouloir supprimer ?
                        </Alert>
                </DialogContent>
                <DialogActions>
                    <Button onClick={this.props.yes} >Oui</Button>
                    <Button onClick={this.props.no} >Non</Button>
                </DialogActions>
            </Dialog>
        );
    }
}