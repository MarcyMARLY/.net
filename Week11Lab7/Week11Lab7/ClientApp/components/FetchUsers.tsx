import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { Link, NavLink } from 'react-router-dom';

interface Usser {
	id: number;
	name: string;
	age: number;
	mark: number;
	category: string;
}
interface UserListState {
	users: Usser[];
	loading: boolean;
}

export class FetchUsers extends React.Component<RouteComponentProps<{}>, UserListState>{

	constructor() {
		super();
		this.state = { users: [], loading: true };
		fetch('api/User').then(response => response.json() as Promise<Usser[]>)
			.then(data => {
				this.setState({
					users: data,
					loading: false,
				});
			});
	}


	public render() {
		let contents = this.state.loading
			? <p><em>Loading...</em></p>
			: this.renderUserTable(this.state.users);
		return <div><h1>Users</h1>
			{contents}
			</div>
	}

	

	handleDelete = async (e: number) => {

		await fetch('api/user/' + e,
			{
				method: 'delete',
				headers: {
				},
			});

		
		await fetch('api/User').then(response => response.json() as Promise<Usser[]>)
			.then(data => {
				console.log(data)
				var loadData = data
				this.setState({
					users: loadData
				})
			});
		FetchUsers.arguments.render();
	}
	handleEdit = async (val: number) => {

	}
	private renderUserTable(users: Usser[]) {
		return <table className='table'>
			<thead>
				<tr>
					
					<th>name</th>
					<th>age</th>
					<th>mark</th>
					<th>category</th>
					<th>DELETE</th>
					<th>EDIT</th>
				</tr>
			</thead>
			<tbody>
				{users.map(user =>
					<tr key={user.id}>
						<td>{user.name}</td>
						<td>{user.age}</td>
						<td>{user.mark}</td>
						<td>{user.category}</td>
						<td><button onClick={() => this.handleDelete(user.id)} type="submit">Delete</button></td>
						<td><button onClick={() => this.handleEdit(user.id)} type="submit"><Link to={'/counter'}>Edit</Link></button></td>
					</tr>
				)}
			</tbody>
		</table>;
	}
}