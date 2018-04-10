import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export interface UserPageProps {
	children?: React.ReactNode;
}
interface UserState {
	id: number;
	name: string;
	age: number;
	mark: number;
	category: string;
	markList: Array<number>;
	categoryList: Array<string>
}
export class UserPage extends React.Component<RouteComponentProps<{}>, UserState> {
	constructor() {
		super();
		this.state = {
			id: 0,
			name: '',
			age: 0,
			mark: 1,
			category: 'friend',
			markList: [1, 2, 3, 4, 5],
			categoryList: ['friend','family','classmate'],

		}
	}
	handleName = (event: any) => {
		this.setState({
			
			name: event.target.value
		});
		console.log(this.state.name);
	}
	handleAge = (event: any) => {
		this.setState({
			age: event.target.value
		});
	}
	handleMark = (val:number) =>{
		
		this.setState({
			mark: val
		});
	}
	handleCategory = (val:string) => {
		
		this.setState({
			category: val
		});
	}

	handleSubmit = (e: any) => {
		e.preventDefault();
		var data = {
			"id": Math.floor(Math.random() * 100) + 1 , "name": this.state.name, "age": this.state.age, "mark": this.state.mark, "category": this.state.category
		}
		console.log(this.state.name);
		fetch('api/user/',
			{
				method: 'POST',
				headers: {
					'Accept': 'application/json',
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(data)
			});
		this.setState({
			id: 0,
			name: '',
			age: 0,
			mark: 1,
			category: 'friend',
		});
	}
	public render() {
		const list = this.state.markList.map((number) => <li key={number.toString()} onClick={() => this.handleMark(number)}><a >{number}</a></li>);
		const listC = this.state.categoryList.map((val) => <li key={val} onClick={() => this.handleCategory(val)}><a>{val}</a></li>);
		return (<div className="container">

			<form className="form-signin">
				<h2 className="form-signin-heading">Add User</h2>
				<label htmlFor="inputName" className="sr-only">Name</label>
				<input type="text" id="inputName" className="form-control" placeholder="Name" onChange={(e) => this.handleName(e)} />
				<label htmlFor="inputAge" className="sr-only">Age</label>
				<input type="text" id="inputAge" className="form-control" placeholder="Age" onChange={(e) => this.handleAge(e)} />
				<div className="dropdown">
					<label htmlFor="inputMark" className="sr-only">Mark</label>
					<button type="text" id="inputMark" className="form-control" placeholder="Mark" data-toggle="dropdown" value={this.state.mark}>{this.state.mark} <span className="caret"></span></button>
					<ul className="dropdown-menu">
						{list}
					</ul>
				</div>
				<div className="dropdown">
					<label htmlFor="inputCategory" className="sr-only">Category</label>
					<button type="text" id="inputCategory" className="form-control" placeholder="Category" data-toggle="dropdown" value={this.state.category}>{this.state.category} <span className="caret"></span></button>
					<ul className="dropdown-menu">
						{listC}
					</ul>
				</div>
				
				<button className="btn btn-lg btn-primary btn-block" type="submit" onClick={(e) => this.handleSubmit(e)}>Sign in</button>
			</form>

		</div>
		)
	}
	

}

