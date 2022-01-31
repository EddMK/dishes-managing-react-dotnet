import React, { Component } from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent  from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import MenuItem from '@mui/material/MenuItem';
import Validation from './Validation';


export default class Modal extends Component {

    constructor(props) {
        super(props);
        if(!this.props.isAdd){
            this.state = {
                showValidation : false,
                openDialog : true, 
                loading: true, 
                isAdd : this.props.isAdd,
                categories : [] , 
                providers : [],
                id : this.props.value.idDish,
                nameInput : this.props.value.label,
                priceInput : this.props.value.price,
                categoryInput : this.props.value.categoryId,
                providerInput : this.props.value.providerId
            };
        }else{
            this.state = {
                showValidation : false,
                openDialog : true, 
                loading: true, 
                isAdd : this.props.isAdd,
                categories : [] , 
                providers : [],
                nameInput : '',
                priceInput : 0,
                categoryInput : '',
                providerInput : ''
            };
        }
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handlePriceChange = this.handlePriceChange.bind(this);
        this.handleCategoryChange = this.handleCategoryChange.bind(this);
        this.handleProviderChange = this.handleProviderChange.bind(this);
        this.handleCloseValidation = this.handleCloseValidation.bind(this);
        this.isValid = this.isValid.bind(this);
    }

    componentDidMount() {
        this.getDatas();
    }

    isValid(){
        if(this.state.nameInput.trim().length === 0){
            return false;
        }if(this.state.categoryInput === ""){
            return false;
        }if(this.state.providerInput === ""){
            return false;
        }if(this.state.priceInput === 0){
            return false;
        }
        return true;
    }

    async handleSubmit() {
        if(!this.isValid()){
            this.setState({showValidation : true})
        }else{


            const url  = 'dish';
            var methode = "";
            var id = 0;
            this.state.isAdd ? methode = "POST" : methode = "PUT";
            this.state.isAdd ? id = 0 : id = this.state.id;
            await fetch(url, {
                method: methode,
                body: JSON.stringify({
                    "idDish": id,
                    "label": this.state.nameInput,
                    "price" : this.state.priceInput ,
                    "categoryId" : this.state.categoryInput,
                    "providerId" : this.state.providerInput
                }),
                headers: {
                    'Content-Type': 'application/json',
                }
            });
            this.props.closeModal();
        }
    }

    handleNameChange(event) {
        this.setState({nameInput : event.target.value});
    }

    handlePriceChange(event) {
        this.setState({priceInput : parseFloat(event.target.value) });
    }

    handleCategoryChange(event) {
        this.setState({categoryInput : event.target.value});
    }

    handleProviderChange(event) {
        this.setState({providerInput : event.target.value});
    }

    handleCloseValidation(){
        console.log("CLIQUE FERMER VALIDATION !");
        this.setState( { showValidation : false } );
      }

    async getDatas() {
        const url  = 'category';
        const resp = await fetch(url);
        const data = await resp.json();
        const url2  = 'provider';
        const resp2 = await fetch(url2);
        const data2 = await resp2.json();
        this.setState({loading : false, categories: data, providers : data2});
    }

    render() {
        return (
            <div>
                <Dialog open={this.state.openDialog}  >
                    <DialogTitle>  { this.state.isAdd ? "Ajout" : "Modification" } d'un plat</DialogTitle>
                    <DialogContent>    
                        <TextField autoFocus type="text" margin="dense" id="name" defaultValue={this.state.nameInput} onChange={this.handleNameChange} label="Libellé du plat"  fullWidth  variant="filled" /> 
                        <TextField id="outlined-select-currency" select label="Famille du plat" value={this.state.categoryInput}  onChange={this.handleCategoryChange} variant="filled" fullWidth>
                            {
                                this.state.categories.map(category => 
                                    <MenuItem  key={category.idCategory}  value={category.idCategory}>{category.name}</MenuItem>
                                )
                            }                        
                        </TextField>
                        <TextField id="outlined-select-currency" select label="Fournisseur" value={this.state.providerInput} onChange={this.handleProviderChange} variant="filled" fullWidth>
                            {
                                this.state.providers.map(provider => 
                                    <MenuItem key={provider.idProvider} value={provider.idProvider}>{provider.name}</MenuItem>
                                )
                            }                       
                        </TextField>
                        <TextField id="filled-number" label="Prix" type="number" defaultValue={this.state.priceInput} onChange={this.handlePriceChange} InputLabelProps={{ shrink: true }} inputProps={{ min:0, step: ".1" , onKeyDown: (event) => {event.preventDefault(); }}} variant="filled" fullWidth/>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleSubmit}>{ this.state.isAdd ? "Ajouter" : "Modifier" }</Button>
                        <Button onClick={this.props.annuleDialog}>Annuler</Button>
                    </DialogActions>
                </Dialog>
                {this.state.showValidation ? <Validation  closePopup = {this.handleCloseValidation} /> : null}
            </div>
        );
    }
}