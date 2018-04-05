import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export interface UserPageProps {
	children?: React.ReactNode;
}
export class UserPage extends React.Component<RouteComponentProps<{}>> {
	constructor() {
		super();
		this.state = {
			id: '',
			name: '',
			age: '',
			mark: '',
			category: '',

		}

	}
	public render() {
		return (<div className="container">

			<form className="form-signin">
				<h2 className="form-signin-heading">Add User</h2>
				<label htmlFor="inputName" className="sr-only">Name</label>
				<input type="text" id="inputName" className="form-control" placeholder="Name" onChange={() => this.handleName} />
				<label htmlFor="inputAge" className="sr-only">Age</label>
				<input type="text" id="inputAge" className="form-control" placeholder="Age" onChange={() => this.handleAge} />
				<label htmlFor="inputMark" className="sr-only">Mark</label>
				<input type="text" id="inputMark" className="form-control" placeholder="Mark" onChange={() => this.handleMark} />
				<label htmlFor="inputCategory" className="sr-only">Category</label>
				<input type="text" id="inputCategory" className="form-control" placeholder="Category" onChange={() => this.handleCategory} />
				<button className="btn btn-lg btn-primary btn-block" type="submit" onClick={() => this.handleSubmit}>Sign in</button>
			</form>

		</div>
		)
	}
	handleName(event: any) {
		this.setState({
			name: event.target.value
		});
	}
	handleAge(event: any) {
		this.setState({
			age: event.target.value
		});
	}
	handleMark(event: any) {
		this.setState({
			mark: event.target.value
		});
	}
	handleCategory(event: any) {
		this.setState({
			category: event.target.value
		});
	}

	handleSubmit(e:any) {
		e.preventDefault();

	}

}

