import React, { Component } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent  from '@mui/material/DialogContent';
import Alert from '@mui/material/Alert';
import AlertTitle from '@mui/material/AlertTitle';

export default class Succes extends Component {

    constructor(props){
        super(props);
        this.state = { open : true };
    }

    render(){
        return(                       
            <Dialog open={this.state.open} >
                <DialogContent>
                        <Alert variant="outlined" severity="success">
                            <AlertTitle>Opération réussie</AlertTitle>
                                {this.props.message}
                        </Alert>
                </DialogContent>
                <DialogActions>
                    <Button onClick={this.props.ok} >Ok</Button>
                </DialogActions>
            </Dialog>
        );
    }
}