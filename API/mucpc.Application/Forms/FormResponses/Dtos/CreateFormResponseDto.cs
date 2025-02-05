﻿using mucpc.Application.Forms.FormQuestions.Responses.Dtos;

namespace mucpc.Application.Forms.FormResponses.Dtos;

public class CreateFormResponseCommand
{
    public long FormId { get; set; }
    public long StudentId { get; set; }
    public List<CreateQuestionResponseDto> QuestionsResponses { get; set; }
}

