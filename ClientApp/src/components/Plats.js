import React, { Component } from 'react';
import Modal from './Modal';
import Succes from './Succes';
import Confirmation from './Confirmation';
import ButtonEdit from './ButtonEdit';
import Checkbox from '@mui/material/Checkbox';
import { GrTrash } from "react-icons/gr";
import { GrAdd } from "react-icons/gr";
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';


export class Plats extends Component {
  listToDelete=[];

  constructor(props) {
    super(props);
    this.state = { dishs: [], listChecked:[], loading: true , openDialog : false , showSucces : false ,showConfirmation : false, showModal : false, isAdd : false, message:"", edit:null};
    this.handleClickOpenAdd = this.handleClickOpenAdd.bind(this);
    this.handleClickOpenEdit = this.handleClickOpenEdit.bind(this);
    this.handleCloseDialog = this.handleCloseDialog.bind(this);
    this.handleCheckBoxDelete = this.handleCheckBoxDelete.bind(this);
    this.handleDelete = this.handleDelete.bind(this);
    this.handleConfirm = this.handleConfirm.bind(this);
    this.handleCloseConfirm = this.handleCloseConfirm.bind(this);
    this.handleSucces = this.handleSucces.bind(this);
    this.handleAnnuleDialog = this.handleAnnuleDialog.bind(this);
  }

  componentDidMount() {
    this.getDishsData();
  }

  static renderDishsTable(dishs, editMethod, deleteDish) {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                  <th></th>
                  <th>Nom</th>
                  <th>Fournisseurs</th>
                  <th>Catégorie</th>
                  <th>Prix</th>
                  <th>Actions</th>
                </tr>
            </thead>
            <tbody>
              {dishs.map(dish =>
                <tr key={dish.label}>
                  <td> <Checkbox onChange={deleteDish} value={dish.idDish}  /> </td>
                  <td>{dish.label}</td>
                  <td>{dish.provider.name}</td>
                  <td>{dish.category.name}</td>
                  <td>{dish.price}</td>
                  <td><ButtonEdit value={dish} onButtonClick={editMethod} /></td>
                </tr>
              )}
            </tbody>
        </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Plats.renderDishsTable(this.state.dishs, this.handleClickOpenEdit, this.handleCheckBoxDelete);

    return (
      <div>
        <Box sx={{ flexGrow: 1 }}>
          <AppBar position="static">
            <Toolbar>
              <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                Gestion des plats
              </Typography>
              {this.state.listChecked.length !== 0 ? <Button variant="contained" onClick={this.handleDelete} color="error">Supprimer <GrTrash/></Button> : null }
              <Button variant="contained" onClick={this.handleClickOpenAdd} color="success">Ajouter <GrAdd/></Button> 
            </Toolbar>
          </AppBar>
        </Box>
        {contents}
        {this.state.showModal ? <Modal  closeModal = {this.handleCloseDialog} annuleDialog = {this.handleAnnuleDialog} isAdd ={this.state.isAdd}  value={this.state.edit} /> : null }
        {this.state.showConfirmation ? <Confirmation  yes ={this.handleConfirm}  no={this.handleCloseConfirm} /> : null }
        {this.state.showSucces ? <Succes ok ={this.handleSucces} message={this.state.message} /> : null }
      </div>
    );
  }

  handleCheckBoxDelete(event){
    if(event.target.checked){
      this.listToDelete = [...this.listToDelete, event.target.value];
      this.setState({listChecked : this.listToDelete});
    }else{
      this.listToDelete = this.listToDelete.filter(id => id !== event.target.value );
      this.setState({listChecked : this.listToDelete});
    }
  }

  handleClickOpenAdd(){
    console.log("CLIQUE OUVRIR ADD !");
    this.setState({ isAdd : true,  showModal : true});
  }

  handleDelete(){
    console.log("SUPPRIMER !");
    this.setState({showConfirmation : true});
  }

  handleConfirm(){
    this.setState({showConfirmation : false});
    this.state.listChecked.forEach(id => this.delete(id))
    this.setState({listChecked : [] });
    this.listToDelete = [];
    this.setState({showSucces : true , message : "Le plat(s) a (ont) bien été supprimé(s)"});
  }

  handleSucces(){
    this.setState({showSucces : false});
  }

  handleCloseConfirm(){
    this.setState({showConfirmation : false});
  }

  handleClickOpenEdit(dish){
    console.log("CLIQUE OUVRIR EDIT !");
    this.setState( { edit : dish, isAdd : false, showModal : true });
  }

  handleAnnuleDialog(){
    this.setState( { showModal : false , isAdd : false} );
  }

  handleCloseDialog(){
    console.log("CLIQUE FERMER PARENT!");
    /*
      Pour la confirmation, vois si isadd est true ou false en fonction de ca quel confirmation a afficher
    */
    let messages = "";
    if(this.state.isAdd){
      messages = "Le plat a bien été ajouté ";
    }else{
      messages = "Le plat a bien été modifié ";
    }
    this.setState({showSucces : true, message : messages });
    this.setState( { showModal : false , isAdd : false} );
    this.componentDidMount();
  }

  async delete(id){
    id = parseInt(id);
    const url  = 'dish/'+id;
    await fetch( url, { method: 'DELETE' });
    this.componentDidMount();
  }

  async getDishsData() {
    const url  = 'dish';
    const resp = await fetch(url);
    const data = await resp.json();
    this.setState({ dishs: data, loading: false});
  }

}
