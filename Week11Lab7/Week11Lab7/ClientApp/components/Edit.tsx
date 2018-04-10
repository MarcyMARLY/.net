import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export interface EditPageProps {
	children?: React.ReactNode;
}

interface EditPerson {
	id: number;
	name: string;
	age: number;
	mark: number;
	category: string;
	markList: Array<number>;
	categoryList: Array<string>
}

export class Edit extends React.Component<RouteComponentProps<{}>, EditPerson>{
	constructor(props: any) {
		super(props);
		this.state = {
			id: this.props.id,
			name: '',
			age: 0,
			mark: 1,
			category: 'friend',
			markList: [1, 2, 3, 4, 5],
			categoryList: ['friend', 'family', 'classmate'],
		}
	}

}