import React, { Component } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent  from '@mui/material/DialogContent';
import Alert from '@mui/material/Alert';
import AlertTitle from '@mui/material/AlertTitle';

export default class Validation extends Component {

    constructor(props){
        super(props);
        this.state = { open : true };
    }

    render(){
        return(                       
            <Dialog open={this.state.open} >
                <DialogContent>
                        <Alert variant="outlined" severity="error">
                            <AlertTitle>Error Formulaire</AlertTitle>
                                Il faut que tous les champs doivent être remplis !
                                (Pour le champ concernant les prix, il faut que cela soit différent de 0)
                        </Alert>
                </DialogContent>
                <DialogActions>
                    <Button onClick={this.props.closePopup}>Ok</Button>
                </DialogActions>
            </Dialog>
        );
    }
}