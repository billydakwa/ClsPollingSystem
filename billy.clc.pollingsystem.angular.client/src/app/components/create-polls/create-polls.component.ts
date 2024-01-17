import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import ValidateForm from 'src/app/helpers/form.validation';
import { PollService } from 'src/app/services/poll.service';

@Component({
  selector: 'app-create-polls',
  templateUrl: './create-polls.component.html',
  styleUrls: ['./create-polls.component.css'],
})
export class CreatePollsComponent implements OnInit {
  pollForm!: FormGroup;
  constructor(private fb: FormBuilder, private poll: PollService) {}

  ngOnInit(): void {
    this.pollForm = this.fb.group({
      pollname: ['', Validators.required],
      question: ['', Validators.required],
      option1: ['', Validators.required],
      option2: ['', Validators.required],
      option3: ['', Validators.required],
      userId: ['65FD1834-DB77-4459-9B15-FF5E03E708FA', Validators.required],
    });
  }

  savePoll() {
    if (this.pollForm.valid) {
      this.poll.createPoll(this.pollForm.value).subscribe({
        next: (res) => {
          alert('Created successfully...');
          this.pollForm.reset();
        },
        error: (err) => {
          console.log(err);
          alert(err.error);
        },
      });
    } else {
      ValidateForm.ValidateAllFormsFields(this.pollForm);
    }
  }
}
